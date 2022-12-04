import React from 'react';
import MainContainer from "../../components/layouts/MainContainer/MainContainer";
import Container from "../../components/layouts/Container/Container";
import Grid from "../../components/layouts/Grid/Grid";
import styles from './CampCardPage.module.scss';
import {Carousel} from "react-carousel-minimal";
import heathBadgeImg from "../../assets/images/badges/health.png";
import campBadgeImg from "../../assets/images/badges/camp.png";
import armyBadgeImg from "../../assets/images/badges/army.png";
import childCampBadgeImg from "../../assets/images/badges/childCamp.png";
import checkBadgeSvg from "../../assets/svg/check.svg";
import {Autocomplete, TextField, Tooltip} from "@mui/material";

const CampCardPage = ({...peops}) => {

	const images = [
		{
			image:'https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg',
		},
		{
			image:'https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg',
		},
		{
			image:'https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg',
		},
		{
			image:'https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg',
		},
		{
			image:'https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg',
		},
{
			image:'https://ok-56.ru/uploads/store/product/11a50b674c4dee7f45e5ab7ee102458b.jpg',
		},

	]

	return (
		<MainContainer>
			<Container>
				<Grid style={{gridTemplateColumns: 'repeat(2,1fr)'}}>
					<div className={styles['images']}>
							<Carousel
								data={images}
								width="500px"
								height="500px"
								radius="10px"
								slideNumber={true}
								dots={true}
								slideImageFit="cover"
								thumbnails={true}
								thumbnailWidth="100px"
								style={{
									textAlign: "center",
									maxWidth: "500px",
									maxHeight: "500px",
									margin: "0px auto",
								}}
							/>
					</div>
					<div className={styles['content']}>
						<h2>Лагерь: Авангард</h2>
						<Grid style={{gridTemplateColumns: 'repeat(2,1fr)', height: '40px'}}>
							<p style={{display: 'flex', alignItems: 'center'}}>Тип лагеря:</p>
							<div className={styles['type-imgs']}>
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
						</Grid>
						<Grid style={{gridTemplateColumns: 'repeat(2,1fr)', height: '40px'}}>
							<p>Время года для отдыха:</p>
							<p>Весенние заезды</p>
						</Grid>
						<Grid style={{gridTemplateColumns: 'repeat(2,1fr)', height: '40px'}}>
							<p style={{display: 'flex', alignItems: 'center'}}>Наличие сертификата на отдых:</p>
							<Tooltip arrow title={"Сертификат подтвержден"}>
								<img src={checkBadgeSvg} alt="" width={40} height={40} />
							</Tooltip>
						</Grid>
						<Grid style={{gridTemplateColumns: 'repeat(2,1fr)', height: '40px'}}>
							<p style={{display: 'flex', alignItems: 'center'}}>Смены:</p>
							<Autocomplete
								disablePortal
								id="combo-box-demo"
								options={[
									{
										label: 'тест',
										id: 1
									},
									{
										label: 'тест 2',
										id: 2
									},
								]}
								sx={{ width: 300 }}
								renderInput={(params) => <TextField {...params} />}
							/>
						</Grid>
					</div>
				</Grid>
			</Container>
		</MainContainer>
	);
};

export default CampCardPage;