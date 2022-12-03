import React from 'react';
import BaseForm from "../BaseForm/BaseForm";
import {ROUTES} from "../../../constants/routes";

const LoginForm = ({...props}) => {
	return (
		<BaseForm
			title={'Вход'}
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