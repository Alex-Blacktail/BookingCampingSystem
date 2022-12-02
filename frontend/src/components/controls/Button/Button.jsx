import React from 'react';
import styles from './Button.module.scss'

const Button = ({children, theme, click, text, ...props}) => {

	const rootClasses = [styles.button]
	if ( theme === 'transparent' ) rootClasses.push(styles['button-transparent'])

	return (
		<button className={rootClasses.join(' ')} onClick={(e) => click(e)}>
			{children}
		</button>
	);
};

export default Button;