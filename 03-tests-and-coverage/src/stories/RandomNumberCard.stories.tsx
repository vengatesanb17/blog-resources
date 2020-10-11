import { Meta,Story } from "@storybook/react/types-6-0";
import React from "react";

import RandomNumberCard from "../RandomNumberCard";

export default {
  title: "RandomNumberCard",
  component: RandomNumberCard,
} as Meta;

const Template: Story = (args) => <RandomNumberCard {...args} />;

export const DefaultState = Template.bind({});
DefaultState.args = {};
