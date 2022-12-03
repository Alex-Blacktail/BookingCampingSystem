import React from 'react';
import {ROUTES} from "../../../constants/routes";
import {useForm} from "react-hook-form";
import {CONSTANTS} from "../../../constants/constants";
import {postData} from "../../../utils/fetch";
import styles from "../BaseForm.module.scss";
import Input from "../../controls/Input/Input";
import Button from "../../controls/Button/Button";
import {Link} from "react-router-dom";

const LoginForm = ({...props}) => {

	const {register, handleSubmit, watch, formState:{errors}} = useForm()

	const onSubmitFormHandler = async data => {
		await postData('/api/authentication/login', data)
			.then((data) => {
				console.log(data)
			})
	}

	return (
		<form className={styles['form-validate']} onSubmit={handleSubmit(data => onSubmitFormHandler(data))}>
			<h3 className={styles['title']}>Войти</h3>
			<div className={styles['form-validate__inputs']}>
				<Input
					register={register(`userName`, {required: true})}
					placeholder={'Логин'}
					name={'userName'}
					type={'text'}
					id={'userName'}
				/>
				<Input
					register={register(`password`, {required: true})}
					placeholder={'Пароль'}
					name={'password'}
					type={'password'}
					id={'password'}
				/>
			</div>
			<div className={styles['form-validate__buttons']}>
				<Button text={'Авторизоваться'}/>
			</div>
			<div className={styles['form-validate__links']}>
				<Link to={ROUTES.register}>Нет аккаунта?</Link>
			</div>
		</form>
	);
};

export default LoginForm;