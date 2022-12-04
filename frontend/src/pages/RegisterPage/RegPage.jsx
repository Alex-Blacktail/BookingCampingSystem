import React from 'react';
import MainContainer from "../../components/layouts/MainContainer/MainContainer";
import Container from "../../components/layouts/Container/Container";
import RegForm from "../../components/forms/RegisterForm/RegForm";

const RegPage = ({...props}) => {
	return (
		<MainContainer>
			<Container>
				<RegForm/>
			</Container>
		</MainContainer>
	);
};

export default RegPage;