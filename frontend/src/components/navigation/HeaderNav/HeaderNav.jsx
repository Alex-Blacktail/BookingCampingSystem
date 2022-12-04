import React, {useContext} from 'react';
import styles from './HeaderNav.module.scss'
import {Link} from "react-router-dom";
import profileSVG from '../../../assets/images/orb-report/contacts_person.svg'
import PersonSVG from "../../svg/personSVG";
import {ROUTES} from "../../../constants/routes";
import {AuthContext} from "../../../context";

const HeaderNav = () => {

	const {userInfo, setUserInfo} = useContext(AuthContext)



	return (
		<nav className={styles['navigation']}>
			<ul className={styles['navigation-list']}>
				<div className={styles['navigation-list__item']}>
					<li>
						<Link to={ROUTES.catalog}>Каталог</Link>
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
					{
						userInfo?.name ?
							<li>
								<Link to={ROUTES.profile}>{userInfo.name}<PersonSVG fill={'#fff'}/></Link>
							</li>
							:
							<li>
								<Link to={ROUTES.login}>Войти <PersonSVG fill={'#fff'}/></Link>
							</li>
					}
				</div>
			</ul>
		</nav>
	);
};

export default HeaderNav;