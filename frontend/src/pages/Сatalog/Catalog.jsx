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

const Catalog = ({...props}) => {
	return (
		<MainContainer>
			<Container>
				<div className={styles['catalog']}>
					<div className={styles['catalog-sorter']}>
						<h6 className={styles['catalog-sorter__title']}>Обозначения</h6>
						<div className={styles['camptype-img']}>
							<img  src={heathBadgeImg} width={40} height={40} alt=""/>
							<p>Санаторный оздоровительный лагерь</p>
						</div>
						<div className={styles['camptype-img']}>
							<img src={campBadgeImg} width={40} height={40} alt=""/>
							<p>Палаточный лагерь</p>
						</div>
						<div className={styles['camptype-img']}>
							<img src={armyBadgeImg} width={40} height={40} alt=""/>
							<p>Военно-патриотический лагерь</p>
						</div>
						<div className={styles['camptype-img']}>
							<img src={childCampBadgeImg} width={40} height={40} alt=""/>
							<p>Детский лагерь</p>
						</div>
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