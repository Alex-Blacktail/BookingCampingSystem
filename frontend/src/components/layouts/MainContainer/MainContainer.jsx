import React from 'react';
import styles from './MainContainer.module.scss'
import HeaderNav from "../../navigation/HeaderNav/HeaderNav";
const MainContainer = ({children, ...props}) => {
	return (
		<>
			<HeaderNav/>
			<main className={styles['main-container']}>
				{children}
			</main>
		</>
	);
};

export default MainContainer;