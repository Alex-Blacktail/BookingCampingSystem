import React, { useContext, useEffect } from "react";
import { ROUTES } from "../../../constants/routes";
import { useForm } from "react-hook-form";
import { CONSTANTS } from "../../../constants/constants";
import { postData } from "../../../utils/fetch";
import styles from "../BaseForm.module.scss";
import Input from "../../controls/Input/Input";
import Button from "../../controls/Button/Button";
import { Link, useNavigate } from "react-router-dom";
import Cookies from "js-cookie";
import { useSnackbar } from "notistack";
import { AuthContext } from "../../../context";

const LoginForm = ({ ...props }) => {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();
  const navigate = useNavigate();
  const { enqueueSnackbar } = useSnackbar();
  const { userInfo, setUserInfo } = useContext(AuthContext);

  const onSubmitFormHandler = async (value) => {
    await postData("/api/authentication/login", value)
      .then((data) => {
        if (data?.token) {
          Cookies.set("token", data?.token);
          Cookies.set("userId", data?.userId);
          Cookies.set("role", data?.role);
          console.log(data);
          setUserInfo({
            token: data?.token,
            userId: data?.userId,
            role: data?.role,
          });
          navigate("/profile");
          enqueueSnackbar("Авторизация прошла успешно", { variant: "success" });
        } else {
          enqueueSnackbar('Не правильный логин или пароль', {variant: 'warning'})
        }
      })
      .catch((err) => {
        enqueueSnackbar("Произошла ошибка", { variant: "error" });
      });
  };

  return (
    <form
      className={styles["form-validate"]}
      onSubmit={handleSubmit((data) => onSubmitFormHandler(data))}
    >
      <h3 className={styles["title"]}>Войти</h3>
      <div className={styles["form-validate__inputs"]}>
        <Input
          register={register(`userName`, {
            required: "Обязательное поле.",
            pattern: {
              value: /^[a-z][a-z0-9]*?([-_][a-z0-9]+){0,2}$/i,
              message:
                'Начинается и кончается на букву и содержит не более двух "_"/"-" подряд.',
            },
          })}
          placeholder={"Логин"}
          name={"userName"}
          type={"text"}
          id={"userName"}
          errMsg={errors?.userName?.message}
        />
        <Input
          register={register(`password`, {
            required: "Обязательное поле.",
            pattern: {
              value: /^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$%&? "]).*$/,
              message: "Латинские буквы + цифры + символ + больше 8 символов",
            },
          })}
          placeholder={"Пароль"}
          name={"password"}
          type={"password"}
          id={"password"}
          errMsg={errors?.password?.message}
        />
      </div>
      <div className={styles["form-validate__buttons"]}>
        <Button text={"Авторизоваться"} />
      </div>
      <div className={styles["form-validate__links"]}>
        <Link to={ROUTES.register}>Нет аккаунта?</Link>
      </div>
    </form>
  );
};

export default LoginForm;