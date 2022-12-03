import React from 'react';
import styles from './Grid.module.scss'

const Grid = ({children, theme, ...props}) => {

	const rootClasses = [styles['grid-container']]
	if (theme === 'box') rootClasses.push(styles['box'])

	return (
		<div {...props} className={rootClasses.join(' ')}>
			{children}
		</div>
	);
};

export default Grid;