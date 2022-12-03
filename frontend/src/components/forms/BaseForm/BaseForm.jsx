import React from 'react';
import {useForm} from "react-hook-form";
import styles from "./BaseForm.module.scss";
import Input from "../../controls/Input/Input";
import Button from "../../controls/Button/Button";
import {Link} from "react-router-dom";

const BaseForm = ({title, inputs, buttons, links, onSubmit, register, ...props}) => {

	return (
		<form className={styles['form-validate']} onSubmit={onSubmit}>
			<h3 className={styles['title']}>{title}</h3>
			<div className={styles['form-validate__inputs']}>
				{
					inputs?.map(input =>
						<Input
							key={`input-${input.name}`}
							register={register(`${input.name}`, {required: true})}
							{...input}/>
					)
				}
			</div>
			<div className={styles['form-validate__buttons']}>
				{
					buttons?.map(button =>
					<Button {...button}/>
					)
				}
			</div>
			<div className={styles['form-validate__links']}>
				{
					links?.map(link =>
					<Link to={link.href}>{link.text}</Link>
					)
				}
			</div>
		</form>
	);
};

export default BaseForm;