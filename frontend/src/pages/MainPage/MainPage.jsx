import React from 'react';
import MainContainer from "../../components/layouts/MainContainer/MainContainer";
import Container from "../../components/layouts/Container/Container";
import Search from "../../components/controls/Search/Search";
import plugImg from "../../assets/images/orb-report/RNIC.jpg"
import CampCard from "../../components/campCard/CampCard";
import Grid from "../../components/layouts/Grid/Grid";
import img from './img.png'

const MainPage = () => {
	return (
		<MainContainer>
			<Container>
				<img src={img} alt=""/>
				<Search style={{marginTop: '100px'}}/>
				<img style={{paddingTop: '30px', margin: '0 auto'}} src={plugImg} alt="plug"width={700}/>
			</Container>
			<Container>
				<h2 style={{textAlign: 'center', marginBottom: '20px'}}>Популярные лагеря</h2>
				<Grid>
					<CampCard/>
					<CampCard/>
					<CampCard/>
					<CampCard/>
				</Grid>
			</Container>
		</MainContainer>
	);
};

export default MainPage;