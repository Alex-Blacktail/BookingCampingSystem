import React from 'react';
import styles from './Select.module.scss'

const Select = ({title, value, register, errMsg, ...props}) => {
	return (
    <>
      <select className={styles["select"]} {...register}>
        <option disabled selected>
          {title}
        </option>
        {value?.map((opt) => (
          <option value={opt.value}>{opt.title}</option>
        ))}
      </select>
      <span className={styles["error"]}>{errMsg}</span>
    </>
  );
};

export default Select;