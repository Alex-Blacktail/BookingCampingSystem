import React from 'react';
import MainContainer from "../../../components/layouts/MainContainer/MainContainer";
import Container from "../../../components/layouts/Container/Container";
import Grid from "../../../components/layouts/Grid/Grid";
import profilePlug from '../../../assets/images/profile/profilePlug.png'
import styles from './ParentProfile.scss'

const ParentProfile = () => {
	return (
		<MainContainer>
			<Container>
				<h3 style={{marginBottom: '40px'}}>Личный кабинет пользователя</h3>
				<Grid style={{gridTemplateColumns: '1fr 4fr'}}>
					<div style={{width: '100%', display:'flex', justifyContent:'center'}}>
						<img src={profilePlug} alt="profile" width={150}/>
					</div>
					<div>
						<h5>Имя: Смелов</h5>
						<h5>Фамилия: Владимир</h5>
						<h5>Отчетсво: Михайлович</h5>
						<h5>Дата рождения: 25.03.1999</h5>
					</div>
				</Grid>
			</Container>
		</MainContainer>
	);
};

export default ParentProfile;