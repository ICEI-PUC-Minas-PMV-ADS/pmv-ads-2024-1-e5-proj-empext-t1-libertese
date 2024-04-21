const showMenu = (toggleId, navbarId, bodyId)=>{
  const toggle = document.getElementById(toggleId),
  navbar = document.getElementById(navbarId),
  bodypadding = document.getElementById(bodyId),
  with_logo = document.getElementById('with-logo'),
  without_logo = document.getElementById('without-logo')

  if(toggle && navbar && with_logo && without_logo){
    toggle.addEventListener('click', ()=>{
      navbar.classList.toggle('expander')
      with_logo.classList.toggle('expander-logo')
      without_logo.classList.toggle('expander-logo')
      bodypadding.classList.toggle('body-pd')
    })
  }
}

showMenu('nav-toggle','navbar','body-pd')
showMenu('logo-toggle','navbar','body-pd')
const linkColor = document.querySelectorAll('.nav__link')
function colorLink(){
  linkColor.forEach(l=> l.classList.remove('active'))
  this.classList.add('active')
}
linkColor.forEach(l=> l.addEventListener('click', colorLink))
const linkCollapse = document.getElementsByClassName('collapse__link')
var i

for(i=0;i<linkCollapse.length;i++){
  linkCollapse[i].addEventListener('click', function(){
    const collapseMenu = this.nextElementSibling
    collapseMenu.classList.toggle('showCollapse')

    const rotate = collapseMenu.previousElementSibling
    rotate.classList.toggle('rotate')
  })
}