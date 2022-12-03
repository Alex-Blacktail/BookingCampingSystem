import React from 'react';
import styles from './Input.module.scss'

const Input = ({label, register, ...props}) => {
	return (
		<label htmlFor={props.id} className={styles['label']}>{label}<input {...props} {...register}/></label>
	);
};

export default Input;