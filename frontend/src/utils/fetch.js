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

export const getData = async (url, data = {}) => {
	const response = await fetch(`${CONSTANTS.baseUrl}${CONSTANTS.basePort}${url}${data.id}`, {
		method: 'GET',
		mode: 'cors',
		// cache: 'no-cache',
		// credentials: 'same-origin',
		// headers: {
		// 	'authorization': `Bearer ${data.token}`,
		// 	'cache-control': 'no-cache,no-store',
		// 	'content-type': 'application/json',
		// 	'pragma': 'no-cache'
		// }
	})
	return await response.json();
}

