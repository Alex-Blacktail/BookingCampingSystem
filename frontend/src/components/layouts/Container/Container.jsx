import React from 'react';
import styles from './Container.module.scss'

const Container = ({children, ...props}) => {
	return (
		<section {...props} className={styles['container']}>
			<div className={styles['container-content']}>
				{children}
			</div>
		</section>
	);
};

export default Container;