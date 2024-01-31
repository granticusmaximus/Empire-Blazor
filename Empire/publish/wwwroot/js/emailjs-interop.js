// emailjs-interop.js
function sendEmail(user_id, service_id, template_id, template_params) {
	emailjs.init(user_id);

	return emailjs.send(service_id, template_id, template_params).then(
		function (response) {
			console.log('SUCCESS!', response.status, response.text);
			return true;
		},
		function (error) {
			console.log('FAILED...', error);
			return false;
		}
	);
}
