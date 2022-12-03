import React from 'react';
import styles from './CampCard.module.scss'
import Button from "../controls/Button/Button";
import heathBadgeImg from '../../assets/images/badges/health.png'
import campBadgeImg from '../../assets/images/badges/camp.png'
import armyBadgeImg from '../../assets/images/badges/army.png'
import childCampBadgeImg from '../../assets/images/badges/childCamp.png'

const CampCard = ({img,  title, ...props}) => {
	return (
		<div className={styles['camp-card']}>
			<img src="https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg" width={128} height={128} alt=""/>
			<p>{title}Авангард</p>
			<div className={styles['camp-card__badges']}>
				<img src={heathBadgeImg} alt="" width={40} height={40}/>
				<img src={campBadgeImg} alt="" width={40} height={40}/>
				<img src={armyBadgeImg} alt="" width={40} height={40}/>
				<img src={childCampBadgeImg} alt="" width={40} height={40}/>
			</div>
			<Button style={{marginTop: '10px'}}
				text={'Подробнее'}
			/>
		</div>
	);
};

export default CampCard;