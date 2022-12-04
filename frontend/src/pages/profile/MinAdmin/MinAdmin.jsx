import React, {useContext, useEffect, useState} from "react";
import MainContainer from "../../../components/layouts/MainContainer/MainContainer";
import Container from "../../../components/layouts/Container/Container";
import Grid from "../../../components/layouts/Grid/Grid";
import profilePlug from "../../../assets/images/profile/profilePlug.png";
import styles from "./MinAdmin.module.scss";
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

const MinAdmin = () => {

  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  const [tab, setTab] = useState("1");

  const [profile, setProfile] = useState(null)

  const handleTabChange = (event, newValue) => {
    setTab(newValue);
  };

  const {userInfo, setUserInfo} = useContext(AuthContext)
  console.log(userInfo)

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
  },[])

  return (
    <MainContainer>
      <Container>
        <TabContext value={tab}>
          <h3 style={{ marginBottom: "40px" }}>Панель администрирования</h3>
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
              <form className={styles["tab-content__form"]}>
                <Input/>
                <Input/>
                <Input/>
              </form>
            </div>
          </TabPanel>
        </TabContext>
      </Container>
    </MainContainer>
  );
};

export default MinAdmin;
