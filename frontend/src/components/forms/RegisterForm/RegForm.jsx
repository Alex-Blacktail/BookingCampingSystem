import React from 'react';
import BaseForm from "../BaseForm/BaseForm";
import {ROUTES} from "../../../constants/routes";

const RegForm = ({...props}) => {
	return (
		<BaseForm
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
				{
					placeholder: 'Пароль (ещё раз)',
					type: 'password',
					name: 'passwordRepeat',
					id: 'passwordRepeat',
				},
			]}
			buttons={[
				{
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