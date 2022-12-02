import React from 'react';
import MainContainer from "../../components/layouts/MainContainer/MainContainer";
import Container from "../../components/layouts/Container/Container";
import Search from "../../components/controls/Search/Search";

const MainPage = () => {
	return (
		<MainContainer>
			<Container>
				<h1>Все что нужно для активного отдыха...</h1>
				<Search/>
			</Container>
		</MainContainer>
	);
};

export default MainPage;