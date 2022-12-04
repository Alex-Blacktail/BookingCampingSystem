import React from 'react';
import MainContainer from "../../components/layouts/MainContainer/MainContainer";
import Container from "../../components/layouts/Container/Container";
import styles from './Catalog.module.scss'
import Search from "../../components/controls/Search/Search";
import heathBadgeImg from '../../assets/images/badges/health.png'
import campBadgeImg from '../../assets/images/badges/camp.png'
import armyBadgeImg from '../../assets/images/badges/army.png'
import childCampBadgeImg from '../../assets/images/badges/childCamp.png'
import Grid from "../../components/layouts/Grid/Grid";
import CampCard from "../../components/campCard/CampCard";
import CheckBox from "../../components/controls/CheckBox/CheckBox";
import {Autocomplete} from "@mui/material";

const Catalog = ({...props}) => {
	const test = [
		{
			label: 'test', year: 123
		},
		{
			label: 'test', year: 123
		},
		{
			label: 'test', year: 123
		},
	]
	return (
		<MainContainer>
			<Container>
				<div className={styles['catalog']}>
					<div className={styles['catalog-sorter']}>
						<h6 className={styles['catalog-sorter__title']}>Тип лагеря</h6>
						<div className={styles['camptype-img']}>
							<img  src={heathBadgeImg} width={40} height={40} alt=""/>
							<p>Санаторный оздоровительный лагерь</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<div className={styles['camptype-img']}>
							<img src={campBadgeImg} width={40} height={40} alt=""/>
							<p>Палаточный лагерь</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<div className={styles['camptype-img']}>
							<img src={armyBadgeImg} width={40} height={40} alt=""/>
							<p>Военно-патриотический лагерь</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<div className={styles['camptype-img']}>
							<img src={childCampBadgeImg} width={40} height={40} alt=""/>
							<p>Детский лагерь</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<h6 className={styles['catalog-sorter__title']}>Время года</h6>
						<div className={styles['sorting-position']}>
							<p>Зимние заезды</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<div className={styles['sorting-position']}>
							<p>Весенние заезды</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<div className={styles['sorting-position']}>
							<p>Летние заезды</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<div className={styles['sorting-position']}>
							<p>Осенние заезды</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						{/*<h6 className={styles['catalog-sorter__title']}>Сроки заезда и название смены</h6>*/}
						<h6 className={styles['catalog-sorter__title']}>Наличие сертификата на отдых</h6>
						<div className={styles['sorting-position']}>
							<p>Сертификат</p>
							<CheckBox className={styles['checkbox']}/>
						</div>
						<h6 className={styles['catalog-sorter__title']}>Смена</h6>
					</div>
					<div className={styles['catalog-content']}>
						<Search />
						<Grid style={{gridTemplateColumns: 'repeat(3, 1fr)', marginTop: '20px'}}>
						<CampCard/>
						<CampCard/>
						<CampCard/>
						<CampCard/>
						<CampCard/>
						<CampCard/>
						</Grid>
					</div>
				</div>
			</Container>
		</MainContainer>
	);
};

export default Catalog;