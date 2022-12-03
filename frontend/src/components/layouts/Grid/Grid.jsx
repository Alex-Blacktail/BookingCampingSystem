import React from 'react';
import styles from './Grid.module.scss'

const Grid = ({children, ...props}) => {
	return (
		<div {...props} className={styles['grid-container']} >
			{children}
		</div>
	);
};

export default Grid;