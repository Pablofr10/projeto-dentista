import { createApp } from "vue";
import App from "./App.vue";
import "./assets/tailwind.css";
import router from "./router";
import { library } from "@fortawesome/fontawesome-svg-core";
import icons from "./utils/icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import VCalendar from "v-calendar";
import store from "./store";

import DefaultLayout from "./layouts/DefaultLayout.vue";

library.add(...icons);

const app = createApp(App);

app.use(store);
app.use(router);
app.use(VCalendar, {});
app.component("fa", FontAwesomeIcon);
app.component("default-layout", DefaultLayout);
app.mount("#app");
