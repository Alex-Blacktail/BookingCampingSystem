import React from 'react';
import MainContainer from "../../components/layouts/MainContainer/MainContainer";
import Container from "../../components/layouts/Container/Container";
import Search from "../../components/controls/Search/Search";
import plugImg from "../../assets/images/orb-report/RNIC.jpg"

const MainPage = () => {
	return (
		<MainContainer>
			<Container>
				<h1>Все что нужно для активного отдыха...</h1>
				<Search/>
				<img style={{paddingTop: '30px', margin: '0 auto'}} src={plugImg} alt="plug"width={700}/>
			</Container>
		</MainContainer>
	);
};

export default MainPage;