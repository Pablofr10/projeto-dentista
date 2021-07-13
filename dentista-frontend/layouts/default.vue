<template>
  <v-app dark>
    <v-navigation-drawer v-model="drawer" dark permanent expand-on-hover app>
      <v-list-item>
        <v-list-item-avatar>
          <v-img src="https://randomuser.me/api/portraits/women/75.jpg" />
        </v-list-item-avatar>
      </v-list-item>

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
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-toolbar-title v-text="title" />
      <v-spacer />
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer :absolute="!fixed" app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      drawer: false,
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
