<template>
  <div>
    <v-expansion-panels focusable>
      <v-expansion-panel v-for="(item, i) in 10" :key="i">
        <v-expansion-panel-header style="border-left: 8px solid green;">
          Item
        </v-expansion-panel-header>
        <v-expansion-panel-content>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
          eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad
          minim veniam, quis nostrud exercitation ullamco laboris nisi ut
          aliquip ex ea commodo consequat.
        </v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
    <div class="text-center">
      <v-pagination v-model="page" :length="4" />
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      page: 1
    }
  }
}
</script>
