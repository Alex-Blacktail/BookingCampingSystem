import React from 'react';
import BaseForm from "../BaseForm/BaseForm";
import {ROUTES} from "../../../constants/routes";
import {useForm} from "react-hook-form";
import {CONSTANTS} from "../../../constants/constants";

const LoginForm = ({...props}) => {

	const {register, handleSubmit, watch, formState:{errors}} = useForm()

	const postData = async (url, data = {}) => {
		const response = await fetch(`${CONSTANTS.baseUrl}${CONSTANTS.basePort}${url}`, {
			method: 'POST',
			mode: 'cors',
			cache: 'no-cache',
			credentials: 'same-origin',
			headers: {
				'Content-type': 'application/json'
			},
			redirect: 'follow',
			referrerPolicy: 'no-referrer',
			body: JSON.stringify(data)
		});
		return await response.json();
	}

	const onSubmitFormHandler = async data => {
		await postData('/api/authentication/register/superadmin', data)
			.then((data) => {
				console.log(data)
			})
	}

	return (
		<BaseForm
			onSubmit={handleSubmit(data => onSubmitFormHandler(data))}
			title={'Вход'}
			register={register}
			inputs={[
				{
					placeholder: 'Логин',
					type: 'text',
					name: 'userName',
					id: 'userName',
				},
				{
					placeholder: 'Пароль',
					type: 'password',
					name: 'password',
					id: 'password',
				},
			]}
			buttons={[
				{
					type: 'submit',
					text: 'Авторизоваться'
				}
			]}
			links={[
				{
					text: 'Нет аккаунта?',
					href: ROUTES.register
				}
			]}
		/>
	);
};

export default LoginForm;