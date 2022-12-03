import React, {useEffect, useRef, useState} from 'react';
import styles from './Search.module.scss'
import Button from "../Button/Button";
import closeSVG from '../../../assets/svg/close.svg'
import searchSVG from '../../../assets/svg/search.svg'

const Search = ({...props}) => {

	const [buttonsVisability, setButtonsVisability] = useState(false)
	const inputRef = useRef(null)

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
		console.log('search')
		alert('!')
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