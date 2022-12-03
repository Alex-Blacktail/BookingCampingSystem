import React from 'react';
import styles from './Input.module.scss'

const Input = ({register, ...props}) => {
	return (
		<input {...props} {...register}/>
	);
};

export default Input;