import React, { useEffect, useState } from "react";
import MainContainer from "../../../components/layouts/MainContainer/MainContainer";
import Container from "../../../components/layouts/Container/Container";
import Grid from "../../../components/layouts/Grid/Grid";
import profilePlug from "../../../assets/images/profile/profilePlug.png";
import styles from "./ParentProfile.module.scss";
import Collapsible from "react-collapsible";
import expandArrowSvg from "../../../assets/svg/expandArrow.svg";
import Button from "../../../components/controls/Button/Button";

const ParentProfile = () => {
  const [collapseState, setCollapseState] = useState({
    info: false,
    children: false,
  });
  useEffect(() => {
    console.log(collapseState);
  }, [collapseState]);
  return (
    <MainContainer>
      <Container>
        <h3 style={{ marginBottom: "40px" }}>Личный кабинет пользователя</h3>
        <Grid style={{ gridTemplateColumns: "1fr 4fr" }} theme={"box"}>
          <div
            style={{ width: "100%", display: "flex", justifyContent: "center" }}
          >
            <img src={profilePlug} alt="profile" width={150} />
          </div>
          <div>
            <h5>Имя: Смелов</h5>
            <h5>Фамилия: Владимир</h5>
            <h5>Отчетсво: Михайлович</h5>
            <h5>Дата рождения: 25.03.1999</h5>
            <div className={styles['profile-buttons']}>
              <Button text={'Добавить ребенка'}/>
              <Button text={'Изменить данные'}/>
              <Button text={'Изменить пароль'}/>
            </div>
          </div>
        </Grid>
        <div style={{ marginTop: "20px" }}>
          <Collapsible
            className={styles["collapse-header"]}
            trigger={
              <div className={styles["collapse-title"]}>
                Личные данные
                <img
                  className={
                    collapseState.info
                      ? [
                          styles["collapse-expand"],
                          styles["collapse-expand__active"],
                        ].join(" ")
                      : styles["collapse-expand"]
                  }
                  src={expandArrowSvg}
                  width={30}
                  alt="expand"
                />
              </div>
            }
            onOpening={() =>
              setCollapseState((prevState) => ({ ...prevState, info: true }))
            }
            onClosing={() =>
              setCollapseState((prevState) => ({ ...prevState, info: false }))
            }
          >
            <p>Паспорт:</p>
          </Collapsible>
        </div>
        <div style={{ marginTop: "20px" }}>
          <Collapsible
            className={styles["collapse-header"]}
            trigger={
              <div className={styles["collapse-title"]}>
                Информация о детях
                <img
                  className={
                    collapseState.children
                      ? [
                          styles["collapse-expand"],
                          styles["collapse-expand__active"],
                        ].join(" ")
                      : styles["collapse-expand"]
                  }
                  src={expandArrowSvg}
                  width={30}
                  alt="expand"
                />
              </div>
            }
            onOpening={() =>
              setCollapseState((prevState) => ({
                ...prevState,
                children: true,
              }))
            }
            onClosing={() =>
              setCollapseState((prevState) => ({
                ...prevState,
                children: false,
              }))
            }
          >
            <p>
              This is the collapsible content. It can be any element or React
              component you like.
            </p>
            <p>
              It can even be another Collapsible component. Check out the next
              section!
            </p>
          </Collapsible>
        </div>
      </Container>
    </MainContainer>
  );
};

export default ParentProfile;
