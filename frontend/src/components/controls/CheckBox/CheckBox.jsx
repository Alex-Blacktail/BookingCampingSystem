import React from 'react';
import {Checkbox} from "@mui/material";

const CheckBox = ({text, ...props}) => {
	return (
    <div {...props}>
      <Checkbox size={"medium"} />
      <span>{text}</span>
    </div>
  );
};

export default CheckBox;