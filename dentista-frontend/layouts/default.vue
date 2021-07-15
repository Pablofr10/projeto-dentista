<template>
  <v-app dark>
    <v-navigation-drawer
      v-model="drawer"
      :mini-variant="miniVariant"
      light
      permanent
      app
      width="200"
    >
      <v-list>
        <v-list-item class="px-2">
          <v-list-item-avatar>
            <v-img src="https://randomuser.me/api/portraits/women/75.jpg" />
          </v-list-item-avatar>
        </v-list-item>

        <v-list-item>
          <v-list-item-content>
            <v-list-item-title class="body-1">
              John Leider
            </v-list-item-title>
            <v-list-item-subtitle>john@vuetifyjs.com</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <v-divider />
      <v-list dense nav>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar fixed app>
      <v-btn icon @click.stop="miniVariant = !miniVariant">
        <v-icon>mdi-{{ `${miniVariant ? 'menu' : 'window-close'}` }}</v-icon>
      </v-btn>
      <v-toolbar-title v-text="title" />
      <v-spacer />
      <v-text-field
        class="mt-5"
        clearable
        rounded
        dense
        solo
        text
        flat
        label="Pesquisar"
        append-icon="mdi-magnify"
      />
      <v-spacer />
      <v-btn icon class="ali" @click.stop="miniVariant = !miniVariant">
        <v-icon :color="miniVariant ? 'silver' : 'pink'">
          mdi-{{ `${miniVariant ? 'bell' : 'bell-ring'}` }}
        </v-icon>
      </v-btn>
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      drawer: false,
      miniVariant: true,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Welcome',
          to: '/'
        },
        {
          icon: 'mdi-book-check-outline',
          title: 'Consultas',
          to: '/consultas'
        },
        {
          icon: 'mdi-account-supervisor-outline',
          title: 'Pacientes',
          to: '/pacientes'
        },
        {
          icon: 'mdi-account-box-multiple-outline',
          title: 'Profissionais',
          to: '/profissionais'
        },
        {
          icon: 'mdi-table-settings',
          title: 'Administração',
          to: '/pacientes'
        }
      ],
      title: 'Odonto Happy'
    }
  }
}
</script>
