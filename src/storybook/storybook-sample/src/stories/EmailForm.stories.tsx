import React from 'react';
import { Story, Meta } from '@storybook/react';
import { EmailForm, EmailFormProps } from "../components/Email/EmailForm";

export default {
  title: 'Components/EmailForm',
  component: EmailForm,
} as Meta;

const Template: Story<EmailFormProps> = (args) => <EmailForm {...args} />

export const Empty = Template.bind({});
Empty.args = { initialValue: "", message: "SUBSCRIBE!!", onSubmit: (e) => { } }

export const OnePart = Template.bind({});
OnePart.args = { initialValue: "pedro", message: "SUBSCRIBE!!", onSubmit: (e) => { } }

export const TwoParts = Template.bind({});
TwoParts.args = { initialValue: "pedro.roque@", message: "SUBSCRIBE!!", onSubmit: (e) => { } }

export const ThreeParts = Template.bind({});
ThreeParts.args = { initialValue: "pedro.roque@outlook", message: "SUBSCRIBE!!", onSubmit: (e) => { } }

export const FourParts = Template.bind({});
FourParts.args = { initialValue: "pedro.roque@outlook.", message: "SUBSCRIBE!!", onSubmit: (e) => { } }

export const FiveParts = Template.bind({});
FiveParts.args = { initialValue: "pedro.roque@outlook.com", message: "SUBSCRIBE!!", onSubmit: (e) => { } }
