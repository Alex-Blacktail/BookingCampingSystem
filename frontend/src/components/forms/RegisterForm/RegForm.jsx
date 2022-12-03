import React, {useState} from 'react';
import {ROUTES} from "../../../constants/routes";
import {useForm} from "react-hook-form";
import {CONSTANTS} from "../../../constants/constants";
import {postData} from "../../../utils/fetch";
import styles from "../BaseForm.module.scss";
import Input from "../../controls/Input/Input";
import Button from "../../controls/Button/Button";
import {Link} from "react-router-dom";
import Select from "../../controls/Select/Select";

const RegForm = ({...props}) => {

	const [pageState,setPageState] = useState(1)
	const {register, watch, handleSubmit, formState: {errors}, setValue} = useForm({
		defaultValues:{
			userName: "",
			firstName: "",
			lastName: "",
			thirdName: "",
			password: "",
			email: "",
			phoneNumber: "",
			address: "",
			country: "",
			snils: "",
			birthday: "",
			passportSerial: "",
			passportNumber: "",
			passportDateOfIssue: "",
			passportIssuedBy: "",
			passportValidity: ""
		}
	})

	const onSubmitFormHandler = async data => {
		if (pageState === 1){
			setPageState(2)
			return
		}
		// await postData('/api/authentication/register/superadmin', data)
		// 	.then((data) => {
		// 		console.log(data)
		// 	})
		console.log(data)
	}

	return (
		<>
			{
				pageState === 1 ?
					<form id={'form-1'} className={styles['form-validate']} onSubmit={handleSubmit(data => onSubmitFormHandler(data))}>
						<h3 className={styles['title']}>Регистрация</h3>
						<div className={styles['form-validate__inputs']}>
							<Input
								register={register(`userName`, {required: true})}
								placeholder={'Логин'}
								name={'userName'}
								type={'text'}
								id={'userName'}
								value={watch('userName')}
							/>
							<Input
								register={register(`email`, {required: true})}
								placeholder={'Эл. почта'}
								name={'email'}
								type={'email'}
								id={'email'}
								value={watch('email')}
							/>
							<Input
								register={register(`firstName`, {required: true})}
								placeholder={'Имя'}
								name={'firstName'}
								type={'text'}
								id={'firstName'}
								value={watch('firstName')}
							/>
							<Input
								register={register(`lastName`, {required: true})}
								placeholder={'Фамилия'}
								name={'lastName'}
								type={'text'}
								id={'lastName'}
								value={watch('lastName')}
							/>
							<Input
								register={register(`thirdName`, {required: true})}
								placeholder={'Отчество'}
								name={'thirdName'}
								type={'text'}
								id={'thirdName'}
								value={watch('thirdName')}
							/>
							<Input
								register={register(`phoneNumber`, {required: true})}
								placeholder={'Телефон'}
								name={'phoneNumber'}
								type={'tel'}
								id={'phoneNumber'}
								value={watch('phoneNumber')}
							/>
							<Input
								register={register(`password`, {required: true})}
								placeholder={'Пароль'}
								name={'password'}
								type={'password'}
								id={'password'}
								value={watch('password')}
							/>
							<Input
								register={register(`passwordRepeat`, {required: true})}
								placeholder={'Пароль (ещё раз)'}
								name={'passwordRepeat'}
								type={'password'}
								id={'passwordRepeat'}
								value={watch('passwordRepeat')}
							/>
						</div>
						<div className={styles['form-validate__buttons']}>
							<Button text={'Далее'}/>
						</div>
						<div className={styles['form-validate__links']}>
							<Link to={ROUTES.login}>Войти</Link>
						</div>
					</form>
					:
					<form id={'form-2'} className={styles['form-validate']} onSubmit={handleSubmit(data => onSubmitFormHandler(data))}>
						<h3 className={styles['title']}>Регистрация</h3>
						<div className={styles['form-validate__inputs']}>
							<Select
								register={register('statusId', {required: true})}
								title={'Выберете статус'}
								value={[
									{
										value: 1,
										title: 'Родитель'
									},
									{
										value: 2,
										title: 'Законный представитель'
									}
								]}
							/>
							<Input
								register={register(`address`, {required: true})}
								placeholder={'Адрес'}
								name={'address'}
								type={'text'}
								id={'address'}
								value={watch('address')}
							/>
							<Input
								register={register(`country`, {required: true})}
								placeholder={'Страна'}
								name={'country'}
								type={'text'}
								id={'country'}
								value={watch('country')}
							/>
							<Input
								register={register(`snils`, {required: true})}
								placeholder={'Снилс'}
								name={'snils'}
								type={'text'}
								id={'snils'}
								value={watch('snils')}
							/>
							<Input
								label={'Дата рождения:'}
								register={register(`birthday`, {required: true})}
								placeholder={'Дата рождения'}
								name={'birthday'}
								type={'date'}
								id={'birthday'}
								value={watch('birthda')}
							/>
							<Select
								register={register(`passportType`, {required: true})}
								title={'Документ удостоверяющий личность'}
								value={[
									{
										value: 'ru',
										title: 'Паспорт гражданина РФ'
									},
									{
										value: 'foreign',
										title: 'Паспорт гражданина другой страны'
									},
								]}
							/>
							{
								watch('passportType') === 'foreign' ?
									<>
										<Input
											label={'Дата истечения паспорта:'}
											register={register(`passportValidity`, {required: true})}
											placeholder={'Дата истечения паспорта'}
											name={'passportValidity'}
											type={'date'}
											id={'passportValidity'}
										/>

									</>
									:
									<></>
							}
							<Input
								register={register(`passportSerial`, {required: true})}
								placeholder={'Серия паспорта'}
								name={'passportSerial'}
								type={'text'}
								id={'passportSerial'}
							/>
							<Input
								register={register(`passportNumber`, {required: true})}
								placeholder={'Номер паспорта'}
								name={'passwordRepeat'}
								type={'text'}
								id={'passwordRepeat'}
							/>
							<Input
								label={'Дата выдачи документа:'}
								register={register(`passportDateOfIssue`, {required: true})}
								placeholder={''}
								name={'passwordRepeat'}
								type={'date'}
								id={'passwordRepeat'}
							/>
							<Input
								register={register(`passportIssuedBy`, {required: true})}
								placeholder={'Кем выдан'}
								name={'passwordRepeat'}
								type={'text'}
								id={'passwordRepeat'}
							/>

						</div>
						<div className={styles['form-validate__buttons']}>
							<Button text={'Зарегистрироваться'} type={'submit'}/>
							<Button text={'Назад'} click={() => setPageState(1)}/>
						</div>
						<div className={styles['form-validate__links']}>
							<Link to={ROUTES.login}>Войти</Link>
						</div>
					</form>
			}
		</>
	);
};

export default RegForm;