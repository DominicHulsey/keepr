<template>
  <div class="home bg-light container-fluid">
    <h1>Welcome to Keepr™</h1>
    <keep-form></keep-form>
    <div class="row">
      <div class="col-10">
        <div class="row justify-content-center mt-4">
          <keep-template v-for="keep in keeps" :keep="keep"></keep-template>
        </div>
      </div>
      <drop @drop="addToVault" class="col-2 mt-4 border sideVault">
        <h3>heyyo</h3>
      </drop>
    </div>
  </div>
</template>

<script>
  import KeepTemplate from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepTemplate.vue"
  import KeepForm from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/keepForm.vue"
  import { Drag, Drop } from 'vue-drag-drop';
  export default {
    name: "home",
    mounted() {
      this.$store.dispatch("getKeeps")
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    },
    components: {
      KeepForm,
      KeepTemplate,
      Drag,
      Drop
    },
    methods: {
      addToVault(keep) {
        console.log(keep)
      }
    }
  };
</script>

<style scoped>
  .sideVault {
    position: sticky !important;
    top: 10vh;
    height: 60vh;
    background: white;
  }
</style>