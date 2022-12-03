import React from 'react';
import styles from './Button.module.scss'

const Button = ({children, theme, click, text, ...props}) => {

	const rootClasses = [styles.button]
	if ( theme === 'transparent' ) rootClasses.push(styles['button-transparent'])

	return (
		<button {...props} className={rootClasses.join(' ')} onClick={(e) => click ? click(e) : {}}>
			{children}{text}
		</button>
	);
};

export default Button;