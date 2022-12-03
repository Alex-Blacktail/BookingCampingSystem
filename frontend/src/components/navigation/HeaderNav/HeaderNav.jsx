import React from 'react';
import styles from './HeaderNav.module.scss'
import {Link} from "react-router-dom";
import profileSVG from '../../../assets/images/orb-report/contacts_person.svg'
import PersonSVG from "../../svg/personSVG";

const HeaderNav = () => {
	return (
		<nav className={styles['navigation']}>
			<ul className={styles['navigation-list']}>
				<div className={styles['navigation-list__item']}>
					<li>
						<Link to={'/'}>Каталог</Link>
					</li>
					<li>
						<Link to={'/'}>О платформе</Link>
					</li>
					<li>
						<Link to={'/'}>Помощь</Link>
					</li>
				</div>
				<div className={styles['navigation-list__item']}>
					{/*<li>*/}
					{/*	<Link to={'/'}><PersonSVG fill={'#fff'}/></Link>*/}
					{/*</li>*/}
				</div>
				<div className={styles['navigation-list__item']}>
					<li>
						<Link to={'/login'}>Войти <PersonSVG fill={'#fff'}/></Link>
					</li>
				</div>
			</ul>
		</nav>
	);
};

export default HeaderNav;