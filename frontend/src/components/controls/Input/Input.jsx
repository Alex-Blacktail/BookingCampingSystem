import React from 'react';
import styles from './Input.module.scss'

const Input = ({label, register, errMsg, ...props}) => {
	return (
		<label htmlFor={props.id} className={styles['label']}>{label}<input {...props} {...register}/><span className={styles['error']}>{errMsg}</span></label>
	);
};

export default Input;