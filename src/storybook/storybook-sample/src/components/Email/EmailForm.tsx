import react, { useState } from "react";
import css from "./EmailForm.module.css";

export interface EmailFormProps {
  initialValue: string;
  message: string;
  onSubmit: (email: string) => void;
};

export const EmailForm = (props: EmailFormProps) => {
  const [email, setEmail] = useState(props.initialValue);
  const emailParts = countEmailParts(email);

  return (<section className={css.container}>
    <div className={css.spectrum} aria-hidden>
      {Array.from(Array(5)).map((_, i) => (<div className={i + 1 <= emailParts ? css.barActive : css.bar} key={i}></div>))}
    </div>
    <header className={css.header}>
      <h2>{props.message}</h2>
    </header>
    <input
      className={css.email}
      type="email"
      placeholder="your email"
      value={email}
      onChange={(evt) => setEmail(evt.target.value)}
    />
    <button className={css.submit}>Sign up</button>
  </section>)
}

const countEmailParts = (email: string): number => {
  if (/@.+\..{2,}$/.test(email)) {
    return 5
  } else if (/@.+\..?$/.test(email)) {
    return 4
  } else if (/@.+$/.test(email)) {
    return 3
  } else if (/@/.test(email)) {
    return 2
  } else if (/.+/.test(email)) {
    return 1
  } else {
    return 0
  }
}