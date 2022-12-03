import React from 'react';
import BaseForm from "../BaseForm/BaseForm";
import {ROUTES} from "../../../constants/routes";
import {useForm} from "react-hook-form";
import {CONSTANTS} from "../../../constants/constants";

const RegForm = ({...props}) => {

	const {register, watch, handleSubmit, formState: {errors}} = useForm()

	const postData = async (url, data = {}) => {
		const response = await fetch(`${CONSTANTS.baseUrl}${CONSTANTS.basePort}`, {
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
			onSubmit={handleSubmit(data => {
				console.log(data)
			})}
			register={register}
			title={'Регистрация'}
			inputs={[
				{
					placeholder: 'Логин',
					type: 'text',
					name: 'userName',
					id: 'userName',
				},
				{
					placeholder: 'Эл. почта',
					type: 'email',
					name: 'email',
					id: 'email',
				},
				{
					placeholder: 'Имя',
					type: 'text',
					name: 'firstName',
					id: 'firstName',
				},
				{
					placeholder: 'Фамилия',
					type: 'text',
					name: 'lastName',
					id: 'lastName',
				},
				{
					placeholder: 'Отчетство',
					type: 'text',
					name: 'thirdName',
					id: 'thirdName',
				},
				{
					placeholder: 'Телефон',
					type: 'tel',
					name: 'phoneNumber',
					id: 'phoneNumber',
				},
				{
					placeholder: 'Пароль',
					type: 'password',
					name: 'password',
					id: 'password',
				},
				// {
				// 	placeholder: 'Пароль (ещё раз)',
				// 	type: 'password',
				// 	name: 'passwordRepeat',
				// 	id: 'passwordRepeat',
				// },
			]}
			buttons={[
				{
					type: 'submit',
					text: 'Зарегистрироваться'
				}
			]}
			links={[
				{
					text: 'Войти',
					href: ROUTES.login
				}
			]}
		/>
	);
};

export default RegForm;