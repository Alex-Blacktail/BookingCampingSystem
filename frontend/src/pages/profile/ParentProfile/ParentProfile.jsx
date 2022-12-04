import React, {useContext, useEffect, useState} from "react";
import MainContainer from "../../../components/layouts/MainContainer/MainContainer";
import Container from "../../../components/layouts/Container/Container";
import Grid from "../../../components/layouts/Grid/Grid";
import profilePlug from "../../../assets/images/profile/profilePlug.png";
import styles from "./ParentProfile.module.scss";
import Collapsible from "react-collapsible";
import expandArrowSvg from "../../../assets/svg/expandArrow.svg";
import Button from "../../../components/controls/Button/Button";
import {AuthContext} from "../../../context";
import {getData, postData} from "../../../utils/fetch";
import {apiRoutes} from "../../../constants/apiRoutes";
import Cookies from 'js-cookie'
import {TabContext, TabList, TabPanel} from "@mui/lab";
import {Tab} from "@mui/material";
import Input from "../../../components/controls/Input/Input";
import {useForm} from "react-hook-form";
import Select from "../../../components/controls/Select/Select";
import {useSnackbar} from "notistack";

const ParentProfile = () => {

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
		reset
  } = useForm();

  const [tab, setTab] = useState("1");

  const [profile, setProfile] = useState(null)
	const { enqueueSnackbar } = useSnackbar();
  const handleTabChange = (event, newValue) => {
    setTab(newValue);
  };

  const {userInfo, setUserInfo} = useContext(AuthContext)

  useEffect(() => {
      if (Cookies.get('token')){
        getData(apiRoutes.get.parentInfo, {id: Cookies.get('userId'), token: Cookies.get('token')})
          .then(data => {
            console.log(data)
            Cookies.set('name', data.firstName)
            setProfile(data)
            console.log(profile)
          })
      }
  },[userInfo])

  const onAddChildrenHandler = async (data) => {
		if (!Cookies.get('userId')){
			return
		}

		{
		}
		data.parentId = Cookies.get('userId')
		data.passportValidity = data.passportValidity ? data.passportValidity : null

    await postData(apiRoutes.post.addChildrenInfo, data).then(res => {
			if(res){
				enqueueSnackbar('Успешно добавлен!', {variant: 'success'})
				reset()
			}
		})
  }

  return (
    <MainContainer>
      <Container>
        <TabContext value={tab}>
          <h3 style={{ marginBottom: "40px" }}>Личный кабинет</h3>
          <Grid
            style={{
              gridTemplateColumns: "1fr 4fr",
              borderBottom: "1px solid lightgray",
            }}
          >
            <div
              style={{
                width: "100%",
                display: "flex",
                justifyContent: "center",
              }}
            >
              <img
                style={{ marginBottom: "10px" }}
                src={profilePlug}
                alt="profile"
                width={150}
              />
            </div>
            <div
              style={{
                display: "flex",
                flexDirection: "column",
              }}
            >
              <h5>{profile?.lastName} {profile?.firstName} {profile?.thirdName}</h5>
              <TabList
                onChange={handleTabChange}
                className={styles["tabs"]}
                aria-label="tabs"
              >
                <Tab label="Контактная информация" value="1" />
                <Tab label="Информация о детях" value="2" />
                <Tab label="Добавление ребенка" value="3" />
              </TabList>
            </div>
          </Grid>
          <TabPanel value="1">
            <h3 className={styles["tab-content__title"]}>
              Контактная информация
              <Grid style={{gridTemplateColumns: '1fr 1fr', alignItems: 'center'}}>
                <h5>Фамилия: </h5><p>{profile?.lastName}</p>
                <h5>Имя: </h5><p>{profile?.firstName}</p>
                <h5>Отчетсво: </h5><p>{profile?.thirdName}</p>
                <h5>Адрес: </h5><p>{profile?.address}</p>
                <h5>Дата рождения: </h5><p>{profile?.birthday}</p>
                <h5>Эл. почта: </h5><p>{profile?.email}</p>
                <h5>Статус: </h5><p>{profile?.status}</p>
                <h5>Снилс: </h5><p>{profile?.snils}</p>
                <h5>Номер телефона: </h5><p>{profile?.phoneNumber}</p>
                <h5>Гражданство: </h5><p>{profile?.country}</p>
                <h5>Тип паспорта: </h5><p>{profile?.passportType}</p>
                <h5>Серия паспорта: </h5><p>{profile?.passportSerial}</p>
                <h5>Номер паспорта: </h5><p>{profile?.passportNumber}</p>
                <h5>Дата выдачи паспорта: </h5><p>{profile?.passportDateOfIssue}</p>
                <h5>Кем выдан паспорта: </h5><p>{profile?.passportIssuedBy}</p>
                <h5>Срок истечения паспорта: </h5><p>{profile?.passportIssuedBy ? profile?.passportIssuedBy : '-'}</p>
              </Grid>
              <div style={{display: 'flex', alignItems:'center', justifyContent:'center', marginTop: '40px'}}>
                <Button text={"Изменить данные и пароль"}/>
              </div>
            </h3>
          </TabPanel>
          <TabPanel value="2">
            <div className={styles["tab-content"]}>
              <h3 className={styles["tab-content__title"]}>
                Информация о детях
              </h3>
            </div>
          </TabPanel>
          <TabPanel value="3">
            <div className={styles["tab-content"]}>
              <h3 className={styles["tab-content__title"]}>
                Форма добавления ребенка
              </h3>
              <form onSubmit={handleSubmit(data => onAddChildrenHandler(data))} className={styles["tab-content__form"]}>
                <Input
                  register={register(`name`, {
                    required: "Обязательное поле.",
                    pattern: {
                      value:
                        /[а-яА-ЯЁё]/,
                      message: "Только символы кириллицы",
                    },
                  })}
                  placeholder={"Имя"}
                  name={"name"}
                  type={"text"}
                  id={"name"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
                <Input
                  register={register(`surname`, {
                    required: "Обязательное поле.",
                    pattern: {
                      value:
                        /[а-яА-ЯЁё]/,
                      message: "Только символы кириллицы",
                    },
                  })}
                  placeholder={"Фамилия"}
                  surname={"surname"}
                  type={"text"}
                  id={"surname"}
                  value={watch("surname")}
                  errMsg={errors?.surname?.message}
                />
                <Input
                  register={register(`patronomyc`, {
                    required: "Обязательное поле.",
                    pattern: {
                      value:
                        /[а-яА-ЯЁё]/,
                      message: "Только символы кириллицы",
                    },
                  })}
                  placeholder={"Отчество"}
                  patronomyc={"patronomyc"}
                  type={"text"}
                  id={"patronomyc"}
                  value={watch("patronomyc")}
                  errMsg={errors?.patronomyc?.message}
                />
                <Input
                  label={"Дата рождения"}
                  register={register(`birthday`, {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Дата рождения"}
                  name={"birthday"}
                  type={"date"}
                  id={"birthday"}
                  errMsg={errors?.birthday?.message}
                />
								<Input
									register={register(`phoneNumber`, {
										required: "Обязательное поле.",
									})}
									placeholder={"Телефон"}
									name={"phoneNumber"}
									type={"tel"}
									id={"phoneNumber"}
									errMsg={errors?.phoneNumber?.message}
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
                  placeholder={"Страна"}
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
                <Select
                  register={register(`documentType`, {
                    required: "Обязательное поле.",
                  })}
                  title={"Документ удостоверяющий личность"}
                  value={[
                    {
                      value: "passportru",
                      title: "Паспорт гражданина РФ",
                    },
                    {
                      value: "passportforeign",
                      title: "Паспорт гражданина другой страны",
                    },
                    {
                      value: "birthru",
                      title: "Свидетельсво о рождеднии гражданина РФ",
                    },
                    {
                      value: "birthforeign",
                      title: "Свидетельсво о рождеднии другой страны",
                    },
                  ]}
                  errMsg={errors?.documentType?.message}
                />
                {watch("documentType") === "passportforeign" ? (
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
                  </>
                ) : (
                  <></>
                )}
              {watch("documentType") === "passportru" ? (
                  <>
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
                  </>
                ) : (
                  <></>
                )}
              {watch("documentType") === "birthru" ? (
                  <>
                  <Input
                    register={register(`birthSerial`, {
                      required: "Обязательное поле.",
                    })}
                    placeholder={"Серия свидетельства"}
                    name={"birthSerial"}
                    type={"text"}
                    id={"birthSerial"}
                    value={watch("birthSerial")}
                    errMsg={errors?.birthSerial?.message}
                  />
                  <Input
                    register={register(`birthNumber`, {
                      required: "Обязательное поле.",
                      pattern: {
                        value:
                          /^[0-9]{6}$/,
                        message: "Некорректный номер свидетельства",
                      },
                    })}
                    placeholder={"Номер свидетельства"}
                    name={"birthNumber"}
                    type={"text"}
                    id={"birthNumber"}
                    value={watch("birthNumber")}
                    errMsg={errors?.birthNumber?.message}
                  />
                  <Input
                    label={"Дата выдачи документа:"}
                    register={register(`birthDateOfIssue`, {
                      required: "Обязательное поле.",
                    })}
                    placeholder={""}
                    name={"birthDateOfIssue"}
                    type={"date"}
                    id={"birthDateOfIssue"}
                    errMsg={errors?.birthDateOfIssue?.message}
                  />
                  <Input
                    register={register(`birthIssuedBy`, {
                      required: "Обязательное поле.",
                      pattern: {
                        value:
                          /^\D+$/,
                        message: "Некорректный ввод",
                      },
                    })}
                    placeholder={"Кем выдан"}
                    name={"birthIssuedBy"}
                    type={"text"}
                    id={"birthIssuedBy"}
                    value={watch("birthIssuedBy")}
                    errMsg={errors?.birthIssuedBy?.message}
                  />
                  </>
                ) : (
                  <></>
                )}
              {watch("documentType") === "birthforeign" ? (
                  <>
                  <Input
                    register={register(`birthSerial`, {
                      required: "Обязательное поле.",
                    })}
                    placeholder={"Серия свидетельства"}
                    name={"birthSerial"}
                    type={"text"}
                    id={"birthSerial"}
                    value={watch("birthSerial")}
                    errMsg={errors?.birthSerial?.message}
                  />
                  <Input
                    register={register(`birthNumber`, {
                      required: "Обязательное поле.",
                    })}
                    placeholder={"Номер свидетельства"}
                    name={"birthNumber"}
                    type={"text"}
                    id={"birthNumber"}
                    value={watch("birthNumber")}
                    errMsg={errors?.birthNumber?.message}
                  />
                  <Input
                    label={"Дата выдачи документа:"}
                    register={register(`birthDateOfIssue`, {
                      required: "Обязательное поле.",
                    })}
                    placeholder={""}
                    name={"birthDateOfIssue"}
                    type={"date"}
                    id={"birthDateOfIssue"}
                    errMsg={errors?.birthDateOfIssue?.message}
                  />
                  <Input
                    register={register(`birthIssuedBy`, {
                      required: "Обязательное поле.",
                    })}
                    placeholder={"Кем выдан"}
                    name={"birthIssuedBy"}
                    type={"text"}
                    id={"birthIssuedBy"}
                    value={watch("birthIssuedBy")}
                    errMsg={errors?.birthIssuedBy?.message}
                  />
                  </>
                ) : (
                  <></>
                )}
              <div style={{display: 'flex', justifyContent: 'center', marginTop: '20px'}}>
                <Button text={"Зарегистрировать ребёнка"} type={"submit"} />
              </div>
              </form>
            </div>
          </TabPanel>
        </TabContext>
      </Container>
    </MainContainer>
  );
};

export default ParentProfile;
