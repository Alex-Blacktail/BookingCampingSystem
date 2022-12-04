import React from "react";
import styles from "./LocalAdminProfile.module.scss";
import MainContainer from "../../../components/layouts/MainContainer/MainContainer";
import Container from "../../../components/layouts/Container/Container";
import Grid from "../../../components/layouts/Grid/Grid";
import profilePlug from "../../../assets/images/profile/profilePlug.png";
import Button from "../../../components/controls/Button/Button";
import { Box, Tab } from "@mui/material";
import { TabContext, TabList, TabPanel } from "@mui/lab";
import Input from "../../../components/controls/Input/Input";
import { useForm } from "react-hook-form";

const LocalAdminProfile = ({ ...props }) => {
  const [tab, setTab] = React.useState("1");

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
      shifts: [
        {
          dateStart: "2022-10-10",
          dateEnd: "2022-10-10",
          name: "Смена",
          shiftTypeDtos: [],
        },
      ],
      features: [
        {
          name: "Для инвалидов",
        },
      ],
    },
  });

  const handleTabChange = (event, newValue) => {
    setTab(newValue);
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
              <form className={styles["tab-content__form"]}>
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
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("address")}
                  errMsg={errors?.address?.message}
                />
                <Input
                  register={register("workingModeDto", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("workingModeDto")}
                  errMsg={errors?.workingModeDto?.message}
                />
                <Input
                  register={register("capacity", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Вместимость"}
                  type={"text"}
                  value={watch("capacity")}
                  errMsg={errors?.capacity?.message}
                />
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
                  register={register("name", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
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
                  register={register("name", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
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
                  register={register("name", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
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
                  register={register("name", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
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
                  register={register("name", {
                    required: "Обязательное поле.",
                  })}
                  placeholder={"Название лагеря"}
                  type={"text"}
                  value={watch("name")}
                  errMsg={errors?.name?.message}
                />
                <h5 style={{marginTop: '20px'}}>Смены:</h5>
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
