import {CONSTANTS} from "../constants/constants";

export const postData = async (url, data = {}) => {
	const response = await fetch(`${CONSTANTS.baseUrl}${CONSTANTS.basePort}${url}`, {
		method: 'POST',
		mode: 'cors',
		cache: 'no-cache',
		credentials: 'same-origin',
		headers: {
			'Content-type': 'application/json'
		},
		redirect: 'follow',
		referrerPolicy: 'no-referrer',
		body: JSON.stringify(data)
	});
	return await response.json();
}

