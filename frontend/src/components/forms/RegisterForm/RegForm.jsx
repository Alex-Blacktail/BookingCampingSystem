import React, { useEffect, useState } from "react";
import { ROUTES } from "../../../constants/routes";
import { useForm } from "react-hook-form";
import { CONSTANTS } from "../../../constants/constants";
import { kladrGetAddres, postData } from "../../../utils/fetch";
import styles from "../BaseForm.module.scss";
import Input from "../../controls/Input/Input";
import Button from "../../controls/Button/Button";
import { Link } from "react-router-dom";
import Select from "../../controls/Select/Select";

const RegForm = ({ ...props }) => {
  const [pageState, setPageState] = useState(1);
  const {
    register,
    watch,
    handleSubmit,
    formState: { errors },
    setValue,
  } = useForm({
    defaultValues: {
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
      passportValidity: "",
    },
  });

  const onSubmitFormHandler = async (data) => {
    if (pageState === 1) {
      setPageState(2);
      return;
    }
    // await postData('/api/authentication/register/superadmin', data)
    // 	.then((data) => {
    // 		console.log(data)
    // 	})
    console.log(data);
  };

  const onSelectValidateHandler = (value) => {
    if (
      value === "Выберете статус" ||
      value === "Документ удостоверяющий личность"
    ) {
      return "Обязательное поле.";
    }
    return true;
  };

  return (
    <>
      {pageState === 1 ? (
        <form
          id={"form-1"}
          className={styles["form-validate"]}
          onSubmit={handleSubmit((data) => onSubmitFormHandler(data))}
        >
          <h3 className={styles["title"]}>Регистрация</h3>
          <div className={styles["form-validate__inputs"]}>
            <Input
              register={register(`userName`, {
                required: "Обязательное поле.",
                pattern: {
                  value: /^[a-z][a-z0-9]*?([-_][a-z0-9]+){0,2}$/i,
                  message:
                    '\'Начинается и кончается на букву и содержит не более двух "_"/"-" подряд.\'',
                },
              })}
              placeholder={"Логин"}
              name={"userName"}
              type={"text"}
              id={"userName"}
              value={watch("userName")}
              errMsg={errors?.userName?.message}
            />
            <Input
              register={register(`email`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                  message: "Эл. почта введена неправильно",
                },
              })}
              placeholder={"Эл. почта"}
              name={"email"}
              type={"email"}
              id={"email"}
              value={watch("email")}
              errMsg={errors?.email?.message}
            />
            <Input
              register={register(`firstName`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /[а-яА-ЯЁё]/,
                  message: "Имя должно содержать только символы кириллицы",
                },
              })}
              placeholder={"Имя"}
              name={"firstName"}
              type={"text"}
              id={"firstName"}
              value={watch("firstName")}
              errMsg={errors?.firstName?.message}
            />
            <Input
              register={register(`lastName`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /[а-яА-ЯЁё]/,
                  message: "Фамилия должна содержать только символы кириллицы",
                },
              })}
              placeholder={"Фамилия"}
              name={"lastName"}
              type={"text"}
              id={"lastName"}
              value={watch("lastName")}
              errMsg={errors?.lastName?.message}
            />
            <Input
              register={register(`thirdName`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /[а-яА-ЯЁё]/,
                  message: "Отчество должно содержать только символы кириллицы",
                },
              })}
              placeholder={"Отчество"}
              name={"thirdName"}
              type={"text"}
              id={"thirdName"}
              value={watch("thirdName")}
              errMsg={errors?.thirdName?.message}
            />
            <Input
              register={register(`phoneNumber`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /^(\+?7-?)?(\([0-9]([0-9]\d[0-9])\)|[0-9]([0-9][0-9]))-?[0-9]([0-9][0-9])-?\d{4}$/,
                  message: "Некорректный номер телефона",
                },
              })}
              placeholder={"Телефон"}
              name={"phoneNumber"}
              type={"tel"}
              id={"phoneNumber"}
              value={watch("phoneNumber")}
              errMsg={errors?.phoneNumber?.message}
            />
            <Input
              register={register(`password`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$%&? "]).*$/,
                  message: "Латинские буквы + цифры + символ + больше 8 символов",
                },
              })}
              placeholder={"Пароль"}
              name={"password"}
              type={"password"}
              id={"password"}
              value={watch("password")}
              errMsg={errors?.password?.message}
            />
            <Input
              register={register(`passwordRepeat`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$%&? "]).*$/,
                  message: "Латинские буквы + цифры + символ + больше 8 символов",
                },
              })}
              placeholder={"Пароль (ещё раз)"}
              name={"passwordRepeat"}
              type={"password"}
              id={"passwordRepeat"}
              value={watch("passwordRepeat")}
              errMsg={errors?.passwordRepeat?.message}
            />
          </div>
          <div className={styles["form-validate__buttons"]}>
            <Button text={"Далее"} />
          </div>
          <div className={styles["form-validate__links"]}>
            <Link to={ROUTES.login}>Войти</Link>
          </div>
        </form>
      ) : (
        <form
          id={"form-2"}
          className={styles["form-validate"]}
          onSubmit={handleSubmit((data) => onSubmitFormHandler(data))}
        >
          <h3 className={styles["title"]}>Регистрация</h3>
          <div className={styles["form-validate__inputs"]}>
            <Select
              register={register("statusId", {
                required: "Обязательное поле.",
                validate: (value) => onSelectValidateHandler(value),
              })}
              title={"Выберете статус"}
              value={[
                {
                  value: 1,
                  title: "Родитель",
                },
                {
                  value: 2,
                  title: "Законный представитель",
                },
              ]}
              errMsg={errors?.statusId?.message}
            />
            <Input
              register={register(`address`, { required: "Обязательное поле." })}
              placeholder={"Адрес"}
              name={"address"}
              type={"text"}
              id={"address"}
              value={watch("address")}
              errMsg={errors?.address?.message}
            />
            <Input
              register={register(`country`, { required: "Обязательное поле." })}
              placeholder={"Гражданство"}
              name={"country"}
              type={"text"}
              id={"country"}
              value={watch("country")}
              errMsg={errors?.country?.message}
            />
            <Input
              register={register(`snils`, {
                required: "Обязательное поле.",
                pattern: {
                  value: /^\d{3}-\d{3}-\d{3}-\d{2}$/,
                  message: "Снилс в формате 132-155-455-45",
                },
              })}
              placeholder={"Снилс"}
              name={"snils"}
              type={"text"}
              id={"snils"}
              value={watch("snils")}
              errMsg={errors?.snils?.message}
            />
            <Input
              label={"Дата рождения:"}
              register={register(`birthday`, {
                required: "Обязательное поле.",
              })}
              placeholder={"Дата рождения"}
              name={"birthday"}
              type={"date"}
              id={"birthday"}
              value={watch("birthday")}
              errMsg={errors?.birthday?.message}
            />
            <Select
              register={register(`passportType`, {
                required: "Обязательное поле.",
              })}
              title={"Документ удостоверяющий личность"}
              value={[
                {
                  value: "ru",
                  title: "Паспорт гражданина РФ",
                },
                {
                  value: "foreign",
                  title: "Паспорт гражданина другой страны",
                },
              ]}
              errMsg={errors?.passportType?.message}
            />
            {watch("passportType") === "foreign" ? (
              <>
                <Input
                  label={"Дата истечения паспорта:"}
                  register={register(`passportValidity`, {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Дата истечения паспорта"}
                  name={"passportValidity"}
                  type={"date"}
                  id={"passportValidity"}
                  errMsg={errors?.passportValidity?.message}
                />
              </>
            ) : (
              <></>
            )}
            <Input
              register={register(`passportSerial`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /^[0-9]{4}$/,
                  message: "Некорректная серия паспорта",
                },
              })}
              placeholder={"Серия паспорта"}
              name={"passportSerial"}
              type={"text"}
              id={"passportSerial"}
              value={watch("passportSerial")}
              errMsg={errors?.passportSerial?.message}
            />
            <Input
              register={register(`passportNumber`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /^[0-9]{6}$/,
                  message: "Некорректный номер паспорта",
                },
              })}
              placeholder={"Номер паспорта"}
              name={"passportNumber"}
              type={"text"}
              id={"passportNumber"}
              value={watch("passportNumber")}
              errMsg={errors?.passportNumber?.message}
            />
            <Input
              label={"Дата выдачи документа:"}
              register={register(`passportDateOfIssue`, {
                required: "Обязательное поле.",
              })}
              placeholder={""}
              name={"passportDateOfIssue"}
              type={"date"}
              id={"passportDateOfIssue"}
              errMsg={errors?.passportDateOfIssue?.message}
            />
            <Input
              register={register(`passportIssuedBy`, {
                required: "Обязательное поле.",
                pattern: {
                  value:
                    /^\D+$/,
                  message: "Некорректный ввод",
                },
              })}
              placeholder={"Кем выдан"}
              name={"passportIssuedBy"}
              type={"text"}
              id={"passportIssuedBy"}
              value={watch("passportIssuedBy")}
              errMsg={errors?.passportIssuedBy?.message}
            />
          </div>
          <div className={styles["form-validate__buttons"]}>
            <Button text={"Зарегистрироваться"} type={"submit"} />
            <Button text={"Назад"} click={() => setPageState(1)} />
          </div>
          <div className={styles["form-validate__links"]}>
            <Link to={ROUTES.login}>Войти</Link>
          </div>
        </form>
      )}
    </>
  );
};

export default RegForm;
