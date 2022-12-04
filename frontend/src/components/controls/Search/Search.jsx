import React, {useEffect, useRef, useState} from 'react';
import styles from './Search.module.scss'
import Button from "../Button/Button";
import closeSVG from '../../../assets/svg/close.svg'
import searchSVG from '../../../assets/svg/search.svg'
import {useLocation, useNavigate} from "react-router-dom";
import {ROUTES} from "../../../constants/routes";

const Search = ({...props}) => {
	const navigation = useNavigate()
	const [buttonsVisability, setButtonsVisability] = useState(false)
	const inputRef = useRef(null)
	const location = useLocation()
	const onInputHandler = e => {
		const targetValue = e.target.value
		if (targetValue){
			if (buttonsVisability){
				return
			}
			setButtonsVisability(true)
			return
		}
		if (buttonsVisability){
			setButtonsVisability(false)
		}
	}

	const onButtonCloseHandler = e => {
		inputRef.current.value = ""
		setButtonsVisability(false)
	}

	const onButtonSearchClick = e => {
		if (location.pathname === '/'){
			navigation(`${ROUTES.catalog}?search=${inputRef?.current?.value}`)
		}
		console.log(location)
	}


	return (
		<div {...props} className={styles['input-container']}>
			<input ref={inputRef} onInput={(e) => onInputHandler(e)} type="text" placeholder={'Поиск...'}/>
			{
				buttonsVisability ?
				<>

					<Button theme={'transparent'} click={onButtonCloseHandler}><img src={closeSVG} alt="close"/></Button>
					<Button click={onButtonSearchClick}><img src={searchSVG} alt="close"/></Button>
				</>
				:<></>
			}
		</div>
	);
};

export default Search;