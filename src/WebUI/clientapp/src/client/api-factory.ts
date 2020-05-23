import { GameClient, IGameClient } from './api';

console.log(`Using api endpoint: ${process.env.VUE_APP_API_BASEURL}`)
const client: IGameClient = new GameClient(process.env.VUE_APP_API_BASEURL);

export default client;