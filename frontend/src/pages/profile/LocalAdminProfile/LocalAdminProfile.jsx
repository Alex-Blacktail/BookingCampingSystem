import React, {useContext, useEffect, useState} from "react";
import styles from "./LocalAdminProfile.module.scss";
import MainContainer from "../../../components/layouts/MainContainer/MainContainer";
import Container from "../../../components/layouts/Container/Container";
import Grid from "../../../components/layouts/Grid/Grid";
import profilePlug from "../../../assets/images/profile/profilePlug.png";
import Button from "../../../components/controls/Button/Button";
import { Box, Checkbox, FormControlLabel, Tab } from "@mui/material";
import { TabContext, TabList, TabPanel } from "@mui/lab";
import Input from "../../../components/controls/Input/Input";
import { useForm } from "react-hook-form";
import plusSVG from "../../../assets/svg/plus.svg";
import CheckBox from "../../../components/controls/CheckBox/CheckBox";
import {getData, postData} from "../../../utils/fetch";
import { apiRoutes } from "../../../constants/apiRoutes";
import jsCookie from "js-cookie";
import {AuthContext} from "../../../context";
import Cookies from "js-cookie";

const LocalAdminProfile = ({ ...props }) => {
  const [tab, setTab] = useState("1");
  const [shifts, setShifts] = useState([
    {
      dateStart: "",
      dateEnd: "",
      name: "",
      typeName: "",
      price: 0,
    },
  ]);
  const [m, sm] = useState(false);
  const [ed, sed] = useState(false);
  const [sert, ssert] = useState(false);
  const handleAddShift = () => {
    const shiftsLen = [...shifts, shifts.length + 1];
    setShifts(shiftsLen);
  };

  const {
    register,
    watch,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    defaultValues: {
      shortName: "лагерек",
      name: "Лагерь",
      legalEntity: "Юр лицо",
      address: "адрес лагерька",
      workingModeDto: "работаем 24/7",
      capacity: 123,
      websiteLink: "https://site.com",
      medicalLicense: true,
      educationalLicense: true,
      about: "немного о нас",
      numberOfBuildings: 8,
      theAreaOfTheLand: 42.2,
      food: "много ешь сладко спишь",
      childsAgeStart: 6.4,
      childsAgeEnd: 15.4,
      childrensHolidayCertificate: true,

      features: [
        {
          name: "Для инвалидов",
        },
      ],
    },
  });
  const [profile, setProfile] = useState(null)

  const handleTabChange = (event, newValue) => {
    setTab(newValue);
  };
  const {userInfo, setUserInfo} = useContext(AuthContext);
  //

  useEffect(() => {
    if (Cookies.get('token')){
      getData(`/api/localadmin/getcampsinfolocal/123`, {id: Cookies.get('userId'), token: Cookies.get('token')})
        .then(data => {
          console.log(data)
          Cookies.set('name', data.name)
          setProfile(data)
          console.log(profile)
        })
    }
  },[userInfo])


  const post = async (data) => {
    data.token = jsCookie.get('token')
    await postData(apiRoutes.post.addCampCard, data).then((res) => {
      console.log(res);
    });
  };

  return (
    <MainContainer>
      <Container>
        <TabContext value={tab}>
          <h3 style={{ marginBottom: "40px" }}>Кабинет организации</h3>
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
                height: "100%",
                display: "flex",
                flexDirection: "column",
              }}
            >
              <h5>Каникулы56</h5>
              <TabList
                onChange={handleTabChange}
                className={styles["tabs"]}
                aria-label="tabs"
              >
                <Tab label="Список лагерей" value="1" />
                <Tab label="Добавить лагерь" value="2" />
                <Tab label="Редактирование лагерей" value="3" />
              </TabList>
            </div>
          </Grid>
          <TabPanel value="1"></TabPanel>
          <TabPanel value="2">
            <div className={styles["tab-content"]}>
              <h3 className={styles["tab-content__title"]}>
                Форма добавления лагеря
              </h3>
              <form
                onSubmit={handleSubmit((data) => post(data))}
                className={styles["tab-content__form"]}
              >
                <Input
                  register={register("name", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
                <Input
                  register={register("shortName", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Краткое название лагеря"}
                  type={"text"}
                  value={watch("shortName")}
                  errMsg={errors?.shortName?.message}
                />
                <Input
                  register={register("legalEntity", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Юр. лицо"}
                  type={"text"}
                  value={watch("legalEntity")}
                  errMsg={errors?.legalEntity?.message}
                />
                <Input
                  register={register("address", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Адрес"}
                  type={"text"}
                  value={watch("address")}
                  errMsg={errors?.address?.message}
                />
                <Input
                  register={register("workingModeDto", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Режим работы"}
                  type={"text"}
                  value={watch("workingModeDto")}
                  errMsg={errors?.workingModeDto?.message}
                />
                <Input
                  register={register("capacity", {
                    required: "Обязательное поле.",
                    validate: (value) =>
                      value > 0 ? true : "Только положительные числа",
                  })}
                  placeholder={"Вместимость"}
                  type={"number"}
                  value={watch("capacity")}
                  errMsg={errors?.capacity?.message}
                />
                <Input
                  register={register("websiteLink", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Веб-сайт"}
                  type={"text"}
                  value={watch("websiteLink")}
                  errMsg={errors?.websiteLink?.message}
                />
                {/*medicalLicense*/}
                <FormControlLabel
                  onChange={() => sm(!m)}
                  control={<Checkbox />}
                  label="Наличие лицензии на осуществлении медицинской деятельности"
                />
                {/*educationalLicense*/}
                <FormControlLabel
                  onChange={() => sed(!ed)}
                  control={<Checkbox />}
                  label="Наличие лицензии на осуществлении медицинской деятельности"
                />
                <Input
                  register={register("about", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"О лагере"}
                  type={"text"}
                  value={watch("about")}
                  errMsg={errors?.about?.message}
                />
                <Input
                  register={register("numberOfBuildings", {
                    required: "Обязательное поле.",
                    validate: (value) =>
                      value > 0 ? true : "Только положительные числа",
                  })}
                  placeholder={"Колличество зданий"}
                  type={"number"}
                  value={watch("numberOfBuildings")}
                  errMsg={errors?.numberOfBuildings?.message}
                />
                <Input
                  register={register("theAreaOfTheLand", {
                    required: "Обязательное поле.",
                    validate: (value) =>
                      value > 0 ? true : "Только положительные числа",
                  })}
                  placeholder={"Площадь"}
                  type={"number"}
                  value={watch("theAreaOfTheLand")}
                  errMsg={errors?.theAreaOfTheLand?.message}
                />
                <Input
                  register={register("food", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Рацион питания"}
                  type={"text"}
                  value={watch("food")}
                  errMsg={errors?.food?.message}
                />
                <Input
                  register={register("childsAgeStart", {
                    required: "Обязательное поле.",
                    validate: (value) =>
                      value > 0 ? true : "Только положительные числа",
                  })}
                  placeholder={"Минимальный возраст"}
                  type={"number"}
                  value={watch("childsAgeStart")}
                  errMsg={errors?.childsAgeStart?.message}
                />
                <Input
                  register={register("childsAgeEnd", {
                    required: "Обязательное поле.",
                    validate: (value) =>
                      value > 0 ? true : "Только положительные числа",
                  })}
                  placeholder={"Максимальный возраст"}
                  type={"number"}
                  value={watch("childsAgeEnd")}
                  errMsg={errors?.childsAgeEnd?.message}
                />
                <FormControlLabel
                  onChange={() => ssert(!sert)}
                  control={<Checkbox />}
                  label="Наличие лицензии на осуществлении медицинской деятельности"
                />

                <h6 style={{ marginTop: "20px" }}>Смена </h6>
                <Input
                  register={register("dateStart", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Дата начала"}
                  type={"text"}
                  value={watch("dateStart")}
                  errMsg={errors?.dateStart?.message}
                />
                <Input
                  register={register("dateEnd", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Дата окончания"}
                  type={"text"}
                  value={watch("dateEnd")}
                  errMsg={errors?.dateEnd?.message}
                />
                <Input
                  register={register("name", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название смены"}
                  type={"text"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
                <Input
                  register={register("typeName", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Тип смены"}
                  type={"text"}
                  value={watch("typeName")}
                  errMsg={errors?.typeName?.message}
                />
                <Input
                  register={register("price", {
                    required: "Обязательное поле.",
                    validate: (value) =>
                      value > 0 ? true : "Только положительные числа",
                  })}
                  placeholder={"Цена"}
                  type={"number"}
                  value={watch("price")}
                  errMsg={errors?.price?.message}
                />
                <div className={styles["tab-content__form__buttons"]}>
                  <Button type={"submit"} text={"Добавить лагерь"} />
                </div>
              </form>
            </div>
          </TabPanel>
          <TabPanel value="3"></TabPanel>
        </TabContext>
      </Container>
    </MainContainer>
  );
};

export default LocalAdminProfile;
