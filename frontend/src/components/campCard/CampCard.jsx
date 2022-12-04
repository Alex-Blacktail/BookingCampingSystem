import React from "react";
import styles from "./CampCard.module.scss";
import Button from "../controls/Button/Button";
import heathBadgeImg from "../../assets/images/badges/health.png";
import campBadgeImg from "../../assets/images/badges/camp.png";
import armyBadgeImg from "../../assets/images/badges/army.png";
import childCampBadgeImg from "../../assets/images/badges/childCamp.png";
import checkBadgeSvg from "../../assets/svg/check.svg";

import { Tooltip } from "@mui/material";
import {useNavigate} from "react-router-dom";

const CampCard = ({ img, title, ...props }) => {

  const navigate = useNavigate()

  return (
    <div className={styles["camp-card"]}>
      <Tooltip arrow className={styles['check']} title={'Сертификат подтвержден'}>
        <img src={checkBadgeSvg} alt="check" />
      </Tooltip>
      <img
        src="https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg"
        width={128}
        height={128}
        alt=""
      />
      <p>{title}Авангард</p>
      <div className={styles["camp-card__badges"]}>
        <Tooltip arrow title={"Санаторный оздоровительный лагерь"}>
          <img src={heathBadgeImg} alt="" width={40} height={40} />
        </Tooltip>
        <Tooltip arrow title={"Палаточный лагерь"}>
          <img src={campBadgeImg} alt="" width={40} height={40} />
        </Tooltip>
        <Tooltip arrow title={"Военно-патриотический лагерь"}>
          <img src={armyBadgeImg} alt="" width={40} height={40} />
        </Tooltip>
        <Tooltip arrow title={"Детский лагерь"}>
          <img src={childCampBadgeImg} alt="" width={40} height={40} />
        </Tooltip>
      </div>
      <Button click={() => navigate('/camp/123')} style={{ marginTop: "10px" }} text={"Подробнее"} />
    </div>
  );
};

export default CampCard;