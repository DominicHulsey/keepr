<template>
  <div class="component">
    <form @submit.prevent="makeKeep">
      <input type="text" v-model="keepForm.name" placeholder="title" />
      <input type="text" v-model="keepForm.description" placeholder="description" />
      <input type="text" v-model="keepForm.img" placeholder="image URL" />
      <button type="submit">Keep</button>
    </form>

  </div>
</template>


<script>
  export default {
    name: '',
    data() {
      return {
        keepForm: {}
      }
    },
    computed: {},
    methods: {
      makeKeep() {
        this.$store.dispatch("makeKeep", this.keepForm)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>