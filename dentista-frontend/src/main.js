import { createApp } from "vue";
import App from "./App.vue";
import "./assets/tailwind.css";
import router from "./router";
import { library } from "@fortawesome/fontawesome-svg-core";
import { faPhone } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import store from "./store";

import DefaultLayout from "./layouts/DefaultLayout.vue";

library.add(faPhone);

const app = createApp(App);

app.use(store);
app.use(router);
app.component("font-awesome-icon", FontAwesomeIcon);
app.component("default-layout", DefaultLayout);
app.mount("#app");
