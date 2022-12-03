import React from 'react';
import styles from './Input.module.scss'

const Input = ({label, register, ...props}) => {
	return (
		<label for={props.id} className={styles['label']}>{label}<input {...props} {...register}/></label>
	);
};

export default Input;