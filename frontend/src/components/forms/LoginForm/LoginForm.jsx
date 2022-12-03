import React from 'react';
import {ROUTES} from "../../../constants/routes";
import {useForm} from "react-hook-form";
import {CONSTANTS} from "../../../constants/constants";
import {postData} from "../../../utils/fetch";
import styles from "../BaseForm.module.scss";
import Input from "../../controls/Input/Input";
import Button from "../../controls/Button/Button";
import {Link, useNavigate} from "react-router-dom";
import Cookies from "js-cookie";

const LoginForm = ({...props}) => {

	const {register, handleSubmit, watch, formState:{errors}} = useForm()
	const navigate = useNavigate()

	const onSubmitFormHandler = async value => {
		await postData('/api/authentication/login', value)
			.then((data) => {
				if (data?.token){
					Cookies.set('token', data?.token)
					Cookies.set('userId', data?.userId)
					Cookies.set('role', data?.role)
					console.log(data)
					navigate('/profile')
				}
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