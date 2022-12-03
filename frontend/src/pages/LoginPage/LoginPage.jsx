import React from 'react';
import MainContainer from "../../components/layouts/MainContainer/MainContainer";
import LoginForm from "../../components/forms/LoginForm/LoginForm";
import Container from "../../components/layouts/Container/Container";

const LoginPage = ({...props}) => {
	return (
		<MainContainer>
			<Container style={{height: '100%'}}>
				<LoginForm/>
			</Container>
		</MainContainer>
	);
};

export default LoginPage;