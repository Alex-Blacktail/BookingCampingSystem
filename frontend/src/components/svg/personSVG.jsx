import React from 'react';

const PersonSvg = ({fill, ...props}) => {
	return (
		<svg {...props} width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
			<path fill-rule="evenodd" clip-rule="evenodd" d="M11.9956 1.8002C9.24143 1.8002 7.00869 4.03293 7.00869 6.78715C7.00869 9.54137 9.24143 11.7741 11.9956 11.7741C14.7499 11.7741 16.9826 9.54137 16.9826 6.78715C16.9826 4.03293 14.7499 1.8002 11.9956 1.8002ZM5.40869 6.78715C5.40869 3.14928 8.35777 0.200195 11.9956 0.200195C15.6335 0.200195 18.5826 3.14928 18.5826 6.78715C18.5826 8.72809 17.7431 10.4729 16.4074 11.6785H19C20.0139 11.6785 20.958 12.1843 21.6304 12.8644C22.3022 13.5441 22.7963 14.4923 22.7913 15.5024V23.8002H1.2V15.4534C1.2 14.4603 1.70267 13.5283 2.37478 12.8632C3.0478 12.1972 3.98896 11.701 4.99767 11.7002C4.99845 11.7002 4.99922 11.7002 5 11.7002L7.59169 11.6855C6.25146 10.4798 5.40869 8.73187 5.40869 6.78715ZM8.52437 13.2803L5.00453 13.3002L5 13.3002C4.50959 13.3002 3.95168 13.5537 3.50022 14.0005C3.04732 14.4487 2.8 14.9933 2.8 15.4534V22.2002H21.1913V15.5002L21.1913 15.4956C21.1941 15.0065 20.9429 14.4449 20.4925 13.9892C20.042 13.5335 19.4861 13.2785 19 13.2785H15.4678L12.7129 18.8546C12.5781 19.1275 12.3 19.3002 11.9956 19.3002C11.6913 19.3002 11.4132 19.1275 11.2784 18.8546L8.52437 13.2803ZM13.753 13.1371L11.9956 16.6941L10.2383 13.1371C10.7977 13.2916 11.387 13.3741 11.9956 13.3741C12.6043 13.3741 13.1936 13.2916 13.753 13.1371Z" fill={fill}/>
		</svg>
	);
};

export default PersonSvg;